        public static IList<Available> Invert(IList<DateTime> input) {
            var result = new List<Available>();
            for (var i = 0; i < input.Count; i += 2) {
                result.Add(
                    new Available(input[i], input[i + 1])
                );
            }
            return result;
        }
