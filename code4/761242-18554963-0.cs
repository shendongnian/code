        if (ML != null)
        {
            Person pers = ML.FirstOrDefault(x => x.Name.ToLower() == p.ToLower());
            if(pers != null)
            {
                  ML.Remove(pers);
                  break;
            }
        }
