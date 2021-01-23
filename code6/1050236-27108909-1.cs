        public static T GetByDescription<T>(string description) {
            return Enum.GetValues(typeof(T))
                .OfType<T>()
                .First(f => {
                    var memberInfo = typeof(T).GetMember(f.ToString());
                    var desc = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    return desc.Length == 1 && ((DescriptionAttribute)desc[0]).Description.Equals(description, StringComparison.InvariantCultureIgnoreCase);
                });
        }
