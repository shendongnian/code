    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Cryptography;
    namespace HashsetTest
    {
        abstract class HashLookupBase
        {
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
            private int _increment;
            public HashsetHashLookup()
            {
                _hashSets = new HashSet<Data256Bit>[16];
                for(int i = 0; i < _hashSets.Length; i++)
                    _hashSets[i] = new HashSet<Data256Bit>();
                _increment = 0;
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
            private readonly Data256Bit[] _objects;
            private int _offset;
            public ArrayHashLookup(int size)
            {
                _objects = new Data256Bit[size];
                _offset = 0;
            }
            public override void CompleteAdding()
            {
                Array.Sort(_objects);
            }
            public override void AddHash(byte[] data)
            {
                _objects[_offset++] = GetHashObject(data);
            }
            public override bool Contains(byte[] data)
            {
                return Array.BinarySearch(_objects, data) >= 0;
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
            static void Main(string[] args)
            {
                var hashClass = new HashsetHashLookup();
                PerformBenchmark(hashClass);
                Console.ReadLine();
            }
            private static void PerformBenchmark(HashLookupBase hashClass, int size = 150000000)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < size; i++)
                    hashClass.AddHash(BitConverter.GetBytes(i));
                Console.WriteLine("Hashing and addition took " + sw.ElapsedMilliseconds + "ms");
                sw.Restart();
                hashClass.CompleteAdding();
                Console.WriteLine("Hash cleanup (sorting, usually) took " + sw.ElapsedMilliseconds + "ms");
                sw.Restart();
                var random = new Random();
                var found = 0;
                var maxValue = (int)(size * 1.25);
                for (int i = 0; i < 10000000; i++)
                {
                    found += hashClass.Contains(BitConverter.GetBytes(random.Next(maxValue))) ? 1 : 0;
                }
                Console.WriteLine("Found " + found + " elements in " + sw.ElapsedMilliseconds + "ms");
            }
        }
    }
