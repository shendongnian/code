    var assembly = typeof(System.Net.Http.Headers.HttpContentHeaders).Assembly;
    var lexer = assembly.GetType("System.Net.Http.Headers.Lexer");
    var field = lexer.GetField("token_chars", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
    var tokens = ( bool[])field.GetValue(null);
    tokens[91] = true;
    tokens[93] = true;
    field.SetValue(null, tokens);
