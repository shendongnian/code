    var sb = new StringBuilder();
    bool insideSpeech = false;
    foreach(char c in code) {
        if(c == '"') {
            insideSpeech = !insideSpeech;
        }
        if(c == '.' && !insideSpeech) {
            sb.Append("::");
        } else {
            sb.Append(code[i]);
        }
    }
    code = sb.ToString();
