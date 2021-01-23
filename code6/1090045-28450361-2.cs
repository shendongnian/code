    static void Main(string[] args)
            {
                var res = new Response();
                res.Users.Add(new User());
                Console.WriteLine(res.IsValid<UserWrapper>().ToString()); // "true"
                Console.WriteLine(res.IsValid<MovieWrapper>().ToString()); // "false"
            }
