        public class MovieList : List<Movie>
        {
            public new void Add(Movie m)
            {
                base.Add(m);
                m.Id = this.IndexOf(m);
            }
            public new void Remove(Movie m)
            {
                base.Remove(m);
                m.Id = -1;
                Reseed();
            }
            public new void RemoveAt(int index)
            {
                Movie m  = this[index];
                this.Remove(m);
            }
            public new int RemoveAll(Predicate<Movie> match)
            {
                List<Movie> removing = new List<Movie>();
                foreach (Movie m in this)
                    if (match(m))
                        removing.Add(m);
                foreach (Movie m in removing)
                {
                    this.Remove(m);
                }
                return removing.Count;
            }
            public new void RemoveRange(int index, int count)
            {
                for (int i = index; i < count; i++)
                {
                    Movie m = this[i];
                    this.Remove(m);
                }
            }
            public new Movie this[int index]
            {
                get
                {
                    return base[index];
                }
                set
                {
                    base[index] = value;
                    Reseed();
                }
            }
            private void Reseed()
            {
                foreach (Movie x in this)
                {
                    x.Id = this.IndexOf(x);
                }
            }
        }
        public class Movie
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Director { get; set; }
        }
