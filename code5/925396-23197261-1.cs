       Dictionary<int, Question> questions = new Dictionary<int, Question>();
        [Serializable]
        public class Question
        {
            public Question(string q_text, Dictionary<string, bool> ans)
            {
                text = q_text;
                answers = ans;
            }
            public string text { get; set; }
            public Dictionary<string, bool> answers { get; set; }
            public static void Save(Question q,Stream st)
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(st, q);
            }
            public static void SaveMany(Dictionary<int, Question> questions,Stream st)
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(st, questions);
            }
            public static Question Load(Stream st)
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Question q = (Question)bf.Deserialize(st);
                return q;
            }
            public static Dictionary<int, Question> LoadMany(Stream st)
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Dictionary<int, Question> q = (Dictionary<int, Question>)bf.Deserialize(st);
                return q;
            }
        }
