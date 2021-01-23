    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    namespace HashsetTest
    {
        class HashLookup
        {
            private readonly HashSet<Data256Bit>[] _hashSets;
            private readonly HashAlgorithm _hasher;
            private int _increment;
            public HashLookup()
            {
                _hashSets = new HashSet<Data256Bit>[16];
                for(int i = 0; i < _hashSets.Length; i++)
                    _hashSets[i] = new HashSet<Data256Bit>();
                _increment = 0;
                _hasher = SHA256.Create();
            }
            public void AddHash(byte[] data)
            {
                var hash = _hasher.ComputeHash(data);
                var item = Data256Bit.FromBytes(hash);
                _hashSets[_increment].Add(item);
                _increment++;
                _increment %= 16;
            }
            public bool Contains(byte[] data)
            {
                var hash = _hasher.ComputeHash(data);
                var target = Data256Bit.FromBytes(hash);
                return _hashSets.Any(h => h.Contains(target));
            }
        }
        struct Data256Bit : IEquatable<Data256Bit>
        {
            public bool Equals(Data256Bit other)
            {
                return _u1 == other._u1 && _u2 == other._u2 && _u3 == other._u3 && _u4 == other._u4;
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
                var sw = Stopwatch.StartNew();
                var hashClass = new HashLookup();
                for(int i = 0; i < 150000000; i++)
                    hashClass.AddHash(BitConverter.GetBytes(i));
                Console.WriteLine("Hashing and addition took " + sw.ElapsedMilliseconds + "ms");
                sw.Restart();
                var random = new Random();
                var found = 0;
                for (int i = 0; i < 100000; i++)
                {
                    found += hashClass.Contains(BitConverter.GetBytes(random.Next(200000000))) ? 1 : 0;
                }
                Console.WriteLine("Found " + found + " elements in " + sw.ElapsedMilliseconds + "ms");
                Console.ReadLine();
            }
            private static byte[] ComputeHash(HashAlgorithm hasher, int data)
            {
                return hasher.ComputeHash(BitConverter.GetBytes(data));
            }
        }
    }
