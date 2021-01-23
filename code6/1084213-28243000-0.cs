    public IEnumerable<int> GetAllRsvpsFor(Guid scheduledId)
        {
            //all the code that precedes the loop
            //for or foreach loop
            {
                //any code that you have to perform after this block
                try
                {
                    var data = x.ToRsvpData(students[x.RawAgentId]);
                }
                catch
                {
                    continue; //continues to the next for iteration in case of any error
                }
                //any code that you have to perform after this block
            }
        }
