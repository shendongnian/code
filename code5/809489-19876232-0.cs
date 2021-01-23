    public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
            {
                return ((f1.FullName.Remove(0, this.pathA.Length)).Equals(f2.FullName.Remove(0, this.pathB.Length)) &&
                        f1.Length == f2.Length);
            }
