                string perm = this.tbxPerm.Text;
                string[] elPerm = perm.Split(',');
                int num;
                for (int i = 0; i < elPerm.Length; i++)
                {
                    if(!int.TryParse(elPerm[i],out num))
                    throw new Exception("Invalid Data Found");
                }
