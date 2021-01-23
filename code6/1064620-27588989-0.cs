            foreach (var item in this.GetType().GetProperties().Where(item => item.Name != "Message"))
            {
                if (!item.GetCustomAttributes(true).OfType<IgnoreAttribute>().Any())
                {
                    command.Parameters.Add(item.Name, item.GetValue(this, null));
                }
            }
