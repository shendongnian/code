    public static IEnumerable<string> InnerTransmogrify(string chars) {
        State state = State.Outside;
        int counter = 0;
        foreach (var @char in chars) {
            switch (state) {
                case State.Outside:
                    switch (@char) {
                        case '{':
                            state = State.OutsideAfterCurly;
                            break;
                        default:
                            yield return @char.ToString();
                            break;
                    }
                    break;
                case State.OutsideAfterCurly:
                    switch (@char) {
                        case '{':
                            state = State.Outside;
                            break;
                        default:
                            state = State.Inside;
                            counter = 0;
                            yield return "(.";
                            break;
                    }
                    break;
                case State.Inside:
                    switch (@char) {
                        case '}':
                            state = State.Outside;
                            yield return "*?)";
                            break;
                        case ':':
                            state = State.InsideAfterColon;
                            break;
                        default:
                            break;
                    }
                    break;
                case State.InsideAfterColon:
                    switch (@char) {
                        case '}':
                            state = State.Outside;
                            yield return "{" + counter + "})";
                            break;
                        default:
                            counter++;
                            break;
                    }
                    break;
            }
        }
    }
