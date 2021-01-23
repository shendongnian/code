     var parts = @event.EventParent.Name.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
    
                        for (int i = 0; i < parts.Length; i++)
                        {
                            if (i >= 2)
                                break;
    
                            parts[i] = parts[i].ToUpper();
                        }
                        @event.EventParent.Name = string.Join("-", parts);
