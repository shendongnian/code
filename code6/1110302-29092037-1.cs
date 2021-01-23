    public class MoneyFormat: IFormatProvider,  ICustomFormatter
            {
                public object GetFormat(Type formatType)
                {
                    if (formatType == typeof(ICustomFormatter))
                        return this;
                    else
                        return null;
                }
    
                public string Format(string fmt, object arg, IFormatProvider formatProvider)
                {
                    if (arg.GetType() != typeof(decimal))
                        try
                        {
                            return HandleOtherFormats(fmt, arg);
                        }
                        catch (FormatException e)
                        {
                            throw new FormatException(string.Format("The format of '{0}' is invalid", fmt), e);
                        }
    
                    string ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
                    if (!(ufmt == "K"))
                        try
                        {
                            return HandleOtherFormats(fmt, arg);
                        }
                        catch (FormatException e)
                        {
                            throw new FormatException(string.Format("The format of '{0}' is invalid", fmt), e);
                        }
    					
    				decimal result;
    				if (decimal.TryParse(arg.ToString(), out result))
    				{
    					if (result >= 1000000)
    					{
    						decimal d = (decimal)Math.Round(result / 10000, 0);
    
    						CultureInfo clone = (CultureInfo)CultureInfo.CurrentCulture.Clone();
    						string oldCurrSymbol = clone.NumberFormat.CurrencySymbol;
    						clone.NumberFormat.CurrencySymbol = "";
    						
    						return String.Format(clone, "{0:C0}", d).Trim() + " K" + oldCurrSymbol;
    					}
    				}
    				else
                    	return string.Format("{0:C0}", result) + " K";
                }
    
                private string HandleOtherFormats(string format, object arg)
                {
                    if (arg is IFormattable)
                        return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
                    else if (arg != null)
                        return arg.ToString();
                    else
                        return string.Empty;
                }
    }
