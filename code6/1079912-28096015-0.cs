        static string GetLinuxArchitectureType()
        {
            Mono.Unix.Native.Utsname result;
            int res = Mono.Unix.Native.Syscall.uname(out result);
            if (res < 0)
                return "N/A";
            return result.machine;
        }
