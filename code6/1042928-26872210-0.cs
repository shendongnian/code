            try
            {
                //do stuff
            }
            catch(FieldAccessException e)
            {
                //Take action on this exception type
                Console.Write(e.Message); 
            }
            catch(NullReferenceException ne)
            { 
                 //Take action on this exception type
                 Console.Write(ne.Message); 
            }
