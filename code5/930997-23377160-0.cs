    var outerRoot = JsonConvert.DeserializeObject<OuterRootObject>(your JSON);
    var root = JsonConvert.DeserializeObject<RootObject>(outerRoot.d);
                            
                                 foreach (var SymbolsInfo in root.Symbols)
                                 {
                                     var i = SymbolsInfo .I;
                                     var a = SymbolsInfo .A;
                                     var b = SymbolsInfo .B;
                                     var l = SymbolsInfo .L;
                                     var h = SymbolsInfo .H;
                                 }
