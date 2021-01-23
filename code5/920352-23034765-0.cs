    private int[] getPiVal()
            {
                string pi = Math.PI + "";
                int[] piarray = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    piarray[i] = Convert.ToInt32(pi[i] + "");
                }
                return piarray;
            }
