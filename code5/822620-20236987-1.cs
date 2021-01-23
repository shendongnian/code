        public List<QuizQuestions> GetQuiz(int level)
        {
            string docName = "DataModel/Level" + level.ToString() + ".xml";
            XDocument xdoc = XDocument.Load(docName); 
            List<QuizQuestions> book = (from list in xdoc.Descendants("Question")
                                        select new QuizQuestions(list.Element("Quest").Value
                                                                 , list.Element("A").Value
                                                                 , list.Element("B").Value
                                                                 , list.Element("C").Value
                                                                 , list.Element("D").Value
                                                                 , list.Element("Answer").Value)
                                                                 ).OrderBy(a => Guid.NewGuid()).ToList();
            return book;
        }
