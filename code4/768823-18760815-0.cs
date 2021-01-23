                Mapper.CreateMap<Src, Dest>().ForMember(d => d.Num, expression => expression.ResolveUsing(src =>
                {
                    if (src.Num == null)
                    {
                        return null;
                    }
                    else
                    {
                        int value;
                        if (int.TryParse(src.Num.InnerStr, out value))
                        {
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }));
