    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Cryptography;
    namespace HashsetTest
    {
        abstract class HashLookupBase
        {
            protected const int BucketCount = 16;
            private readonly HashAlgorithm _hasher;
            protected HashLookupBase()
            {
                _hasher = SHA256.Create();
            }
            public abstract void AddHash(byte[] data);
            public abstract bool Contains(byte[] data);
            private byte[] ComputeHash(byte[] data)
            {
                return _hasher.ComputeHash(data);
            }
            protected Data256Bit GetHashObject(byte[] data)
            {
                var hash = ComputeHash(data);
                return Data256Bit.FromBytes(hash);
            }
            public virtual void CompleteAdding() { }
        }
        class HashsetHashLookup : HashLookupBase
        {
            private readonly HashSet<Data256Bit>[] _hashSets;
            public HashsetHashLookup()
            {
                _hashSets = new HashSet<Data256Bit>[BucketCount];
                for(int i = 0; i < _hashSets.Length; i++)
                    _hashSets[i] = new HashSet<Data256Bit>();
            }
            public override void AddHash(byte[] data)
            {
                var item = GetHashObject(data);
                var offset = item.GetHashCode() & 0xF;
                _hashSets[offset].Add(item);
            }
            public override bool Contains(byte[] data)
            {
                var target = GetHashObject(data);
                var offset = target.GetHashCode() & 0xF;
                return _hashSets[offset].Contains(target);
            }
        }
        class ArrayHashLookup : HashLookupBase
        {
            private Data256Bit[][] _objects;
            private int[] _offsets;
            private int _bucketCounter;
            public ArrayHashLookup(int size)
            {
                size /= BucketCount;
                _objects = new Data256Bit[BucketCount][];
                _offsets = new int[BucketCount];
                
                for(var i = 0; i < BucketCount; i++) _objects[i] = new Data256Bit[size + 1];
                _bucketCounter = 0;
            }
            public override void CompleteAdding()
            {
                for(int i = 0; i < BucketCount; i++) Array.Sort(_objects[i]);
            }
            public override void AddHash(byte[] data)
            {
                var hashObject = GetHashObject(data);
                _objects[_bucketCounter][_offsets[_bucketCounter]++] = hashObject;
                _bucketCounter++;
                _bucketCounter %= BucketCount;
            }
            public override bool Contains(byte[] data)
            {
                var hashObject = GetHashObject(data);
                return _objects.Any(o => Array.BinarySearch(o, hashObject) >= 0);
            }
        }
        struct Data256Bit : IEquatable<Data256Bit>, IComparable<Data256Bit>
        {
            public bool Equals(Data256Bit other)
            {
                return _u1 == other._u1 && _u2 == other._u2 && _u3 == other._u3 && _u4 == other._u4;
            }
            public int CompareTo(Data256Bit other)
            {
                var rslt = _u1.CompareTo(other._u1);    if (rslt != 0) return rslt;
                rslt = _u2.CompareTo(other._u2);        if (rslt != 0) return rslt;
                rslt = _u3.CompareTo(other._u3);        if (rslt != 0) return rslt;
                return _u4.CompareTo(other._u4);
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                    return false;
                return obj is Data256Bit && Equals((Data256Bit) obj);
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = _u1.GetHashCode();
                    hashCode = (hashCode * 397) ^ _u2.GetHashCode();
                    hashCode = (hashCode * 397) ^ _u3.GetHashCode();
                    hashCode = (hashCode * 397) ^ _u4.GetHashCode();
                    return hashCode;
                }
            }
            public static bool operator ==(Data256Bit left, Data256Bit right)
            {
                return left.Equals(right);
            }
            public static bool operator !=(Data256Bit left, Data256Bit right)
            {
                return !left.Equals(right);
            }
            private readonly long _u1;
            private readonly long _u2;
            private readonly long _u3;
            private readonly long _u4;
            private Data256Bit(long u1, long u2, long u3, long u4)
            {
                _u1 = u1;
                _u2 = u2;
                _u3 = u3;
                _u4 = u4;
            }
            public static Data256Bit FromBytes(byte[] data)
            {
                return new Data256Bit(
                    BitConverter.ToInt64(data, 0),
                    BitConverter.ToInt64(data, 8),
                    BitConverter.ToInt64(data, 16),
                    BitConverter.ToInt64(data, 24)
                );
            }
        }
        class Program
        {
            private const int TestSize = 150000000;
            static void Main(string[] args)
            {
                GC.Collect(3);
                GC.WaitForPendingFinalizers();
                {
                    var arrayHashLookup = new ArrayHashLookup(TestSize);
                    PerformBenchmark(arrayHashLookup, TestSize);
                }
                GC.Collect(3);
                GC.WaitForPendingFinalizers();
                {
                    var hashsetHashLookup = new HashsetHashLookup();
                    PerformBenchmark(hashsetHashLookup, TestSize);
                }
                Console.ReadLine();
            }
            private static void PerformBenchmark(HashLookupBase hashClass, int size)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < size; i++)
                    hashClass.AddHash(BitConverter.GetBytes(i * 2));
                Console.WriteLine("Hashing and addition took " + sw.ElapsedMilliseconds + "ms");
                sw.Restart();
                hashClass.CompleteAdding();
                Console.WriteLine("Hash cleanup (sorting, usually) took " + sw.ElapsedMilliseconds + "ms");
                sw.Restart();
                var found = 0;
                
                for (int i = 0; i < size * 2; i += 10)
                {
                    found += hashClass.Contains(BitConverter.GetBytes(i)) ? 1 : 0;
                }
                Console.WriteLine("Found " + found + " elements (expected " + (size / 5) + ") in " + sw.ElapsedMilliseconds + "ms");
            }
        }
    }
