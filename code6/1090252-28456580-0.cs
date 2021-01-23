    public List<Car> getCars(int fromYear, int toYear)
        {
            List<Car> newList = new List<Car>();
            foreach (Car c in Fleet)
            {
                if(c.getDate() < toYear)
                {
                    if (c.getDate() > fromYear)
                    {
                        newList.Add(c);
                    }
                }
            }
            return newList;
        }
