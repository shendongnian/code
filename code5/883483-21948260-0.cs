public class SolverDataA {}
public class SolverDataB {}
public interface IParserA {
    SolverDataA Parse(string input);
}
public interface IParserB {
    SolverDataA Parse(string input);
}
public interface ISolver {
    string Execute(string input);
}
public class SolverA: ISolver {
   private readonly IParserA parser;
   public SolverA(IParserA parser){
      Requires.IsNotNull(parser, "parser");
      this.parser = parser;
   }
   public string Execute(string input) {
      SolverDataA da = parser.Parse(input);
      // solve
      return s;
   }
}
public class SolverB: ISolver {
   private readonly IParserB parser;
   public SolverB(IParserB parser){
      Requires.IsNotNull(parser, "parser");
      this.parser = parser;
   }
   public string Execute(string input) {
      SolverDataB db = parser.Parse(input);
      // solve
      return s;
   }
}
?
