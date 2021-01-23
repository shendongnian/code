    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    public static class Program
    {
    [Flags]
    public enum DataFiat
    {
      [Description("Público")]
      Public = 1,
      [Description("Filiado")]
      Listed = 2,
      [Description("Cliente")]
      Client = 4
    } 
    public static ICollection<string> GetAttribute<T>(this Enum value)
    {
      var result = new Collection<string>();
      var type = typeof(DataFiat);
      foreach (var value1 in Enum.GetValues(type))
      {
        var memInfo = type.GetMember(value1.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        var description = ((DescriptionAttribute)attributes[0]).Description;
        result.Add(description);
      }
      return result;
    }
    static void Main(string[] args)
    {
      var x = DataFiat.Public | DataFiat.Listed;
      var y = x.GetAttribute<DataFiat>();
      var output = string.Join(" ", y.ToArray());
      Console.WriteLine(output);
    }
    }
