     public Prolog()
        {
            //read file
            try
            {
                PlEngine.Initialize(new Object[]);
                //get my Objects
                PlQuery.PlCall("consult(vuelos)"); //HERE IS THE CHANGE
                using (PlQuery q = new PlQuery("aeropuerto(ID,NAME)"))
                {
                    //I do stuff here (omitted)
                }
            }
            catch (PlException e)
            {
                Console.WriteLine(e.MessagePl);
                Console.WriteLine(e.Message);
            }
            finally
            {
                PlEngine.PlCleanup();
            }
        }
