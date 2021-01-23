    private string[] jobs = { "Zone 2", "Zone 4", "Zone 45" };
        private string[] cars = {"Frank", "John", "Mary"};
        private void CheckJobs(){
            var k = new Combinatorics.Collections.Variations<string>(jobs.ToList(),3);
            foreach (var c in k)
            {
                int count = 0;
                for (int i = 0; i < 3; i++)
                {
                    if(IsPossible(cars[i],c[i])) count++;
                    Console.Write("Driver {0} takes {1}   ", cars[i], c[i]);
                }
                Console.WriteLine("Jobs done = {0}", count);
            }
        }
        private Boolean IsPossible(string car, string job)
        {
            if (car == "Mary") {
                return (job == "Zone 2");
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckJobs();
        }
