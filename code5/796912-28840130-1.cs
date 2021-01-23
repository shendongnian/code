        /// <summary>
        /// Parses the arguments; sets the params struct.
        /// </summary>
        /// <param name="argv">The argv.</param>
        /// <param name="paramStruct">The parameter structure.</param>
        /// <returns>true if <see cref="ShowHelp"/> needed.</returns>
        static bool ParseArgs(IEnumerable<string> argv, out ParamStruct paramStruct)
        {
            paramStruct = new ParamStruct();
            try { /* TODO: parse the arguments and set struct fields */ }
            catch { return false; }
            return argv.Select(s => s.ToLowerInvariant()).Intersect(new[] { "help", "/?", "--help", "-help", "-h" }).Any();
        }
