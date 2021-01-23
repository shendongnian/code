    var result = test.Aggregate(new Dictionary<char,int>(), (state,c)=>{
                    if(!state.ContainsKey(c)) { state.Add(c,0); }
                    state[c] += 1;
                    return state;
                 });
    foreach(var pair in result) { Console.WriteLine(pair.Key + " " + key.Value); }
