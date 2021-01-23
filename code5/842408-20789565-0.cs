        public void studentCount()
        {
            string highestScoringStudent;
            int highestScore = 0;
    
            Console.WriteLine("Enter how many students there are: ");
            var studentCount = Convert.ToInt32(Console.ReadLine());
            {
                for (var i = 0; i < studentCount; i++)
                {
                    Console.WriteLine("Enter students name: ");
                    var tempStudent = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter students score: ");
                    var tempScore = Convert.ToInt32(Console.ReadLine());
                    if(tempScore > highestScore)
                    {
                        highestScore = tempScore;
                        highestScoringStudent = tempStudent;
                    }
                }
            }
         }
