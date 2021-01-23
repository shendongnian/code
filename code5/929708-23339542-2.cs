            if (poco1.IsNotNull() && poco2.IsNotNull())
            {
                bool areSame = true;
                foreach(var property in typeof(TPOCO).GetPublicProperties())
                {
                    object v1 = property.GetValue(poco1, null);
                    object v2 = property.GetValue(poco2, null);
                    if (!object.Equals(v1, v2))
                    {
                        areSame = false;
                        break;
                    }
                };
                return areSame;
            } else {
                return false;
            }
