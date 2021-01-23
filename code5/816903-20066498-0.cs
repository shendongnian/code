        [Serializable]
        public class temp
        {
           public int a;
        }
        class Program
        {
            public static T DeepClone<T>(T a)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, a);
                    stream.Position = 0;
                    return (T)formatter.Deserialize(stream);
                }
            }
            static void Main(string[] args)
            {
                List<temp> list1 = new List<temp>();
                list1.Add(new temp { a = 1 });
                list1.Add(new temp { a = 2 });
                list1.Add(new temp { a = 3 });
                List<temp> list2 = DeepClone<List<temp>>(list1);
                list1[1].a = 4;
                Console.WriteLine(list2[1].a);
                Console.ReadKey();
            }
        }
