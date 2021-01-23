    class Program
    {
        static void Main()
        {
            try
            {
                string json = "{\"Questions\": [{ \"Question\": \"Who was the Chola King who brought Ganga from North to South?\", \"CorrectAnswer\": 1, \"Answers\": [ { \"Answer\": \"Raja Raja Chola\" }, { \"Answer\": \"Rajendra Chola\" }, { \"Answer\": \"Parantaka\" }, { \"Answer\": \"Mahendra\" } ] }, { \"Question\": \"The writ of 'Habeas Corpus' is issued in the event of:\", \"CorrectAnswer\": 2 , \"Answers\": [{ \"Answer\": \"Loss of Property\" }, { \"Answer\": \"Refund of Excess Taxes\" }, { \"Answer\": \"Wrongful Police Detention\" }, { \"Answer\": \"Violation of the Freedom of Speech\" }] }]}}";
                QuestionsRepository newRepository = json.DeserializeObject<QuestionsRepository>();
                for (int i = 0; i < newRepository.Questions.Count; i++)
                {
                    Console.WriteLine("{0}", newRepository.Questions[i].Question);
                    int count = 1;
                    foreach (var answer in newRepository.Questions[i].Answers)
                    {
                        Console.WriteLine("\t{0}) {1} ({2})", count, answer.Answer, newRepository.Questions[i].CorrectAnswer == count ? "+" : "-");
                        count++;
                    }
                }
            }
            catch (SerializationException serEx)
            {
                Console.WriteLine(serEx.Message);
                Console.WriteLine(serEx.StackTrace);
            }
        }
    }
