    private static List<TimeRange> GetFreeSlots(TimeRange main, List<TimeRange> except)
    {
        // 1. ignore Ranges outside
        except = except.Where(e => main.Start < e.End && main.End > e.Start).ToList();
        // 2. shrink the main timerange from overlapping ranges
        while (true)
        {
            var x = except.FirstOrDefault(e => e.Start <= main.Start);
            if (x != null)
            {
                if (x.End >= main.End)
                {
                    return new List<TimeRange>();
                }
                main.Start = x.End;
                except.Remove(x);
            }
            else
                break;
        }
        while (true)
        {
            var x = except.FirstOrDefault(e => e.End >= main.End);
            if (x != null)
            {
                main.End = x.Start;
                except.Remove(x);
            }
            else
                break;
        }
        if (!except.Any())
        {
            return new List<TimeRange> { main };
        }
            
        // 3. add start main to start of the 1. exception and shrink the main time range to start = end of the 1. exception and go through the procedure again                      
        except.OrderBy(e => e.Start);
        var valid = new List<TimeRange>{new TimeRange{Start = main.Start, End = except[0].Start}};
        main.Start = except[0].End;
        except.RemoveAt(0);
        return valid.Union(GetFreeSlots(main, except)).ToList();
    }
