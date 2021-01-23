      public override bool Equals(object obj)
            {
                if (obj is Entity)
                {
                    Entity other = (Entity) obj;
                    return this.Id == other.Id;
                }
                else
                {
                    return false;
                }
            }
