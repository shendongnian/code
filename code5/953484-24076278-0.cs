    using System;
    namespace HasAccess
    {
        [Flags]
        enum Permission
        {
            ACCESS = 1,
            READ = 2,
            WRITE = 4
        }
        class Program
        {
            static void Main(string[] args)
            {
                var permissons = Permission.ACCESS | Permission.READ;
                Console.WriteLine(permissons.HasFlag(Permission.ACCESS | Permission.READ));
            }
        }
    }
