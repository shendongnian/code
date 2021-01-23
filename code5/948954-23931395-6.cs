    using System.Collections.Generic;
    
    public class Message {
        public List<Page> Pages { get; private set; }
        public Message() { Pages = new List<Page>(); }
    }
    public class Page {
        public List<Line> Lines { get; private set; }
        public Page() { Lines = new List<Line>(); }
    }
    public class Line {
        public string Text { get; private set; }
        public static implicit operator Line(string value) {
            return new Line { Text = value };
        }
    }
    
    static class Program {
        static void Main() {
            var msg = new Message {
                Pages = {
                    new Page {
                        Lines = { "Test" }
                    },
                    new Page {
                        Lines = {
                            "On another page",
                            "With two lines"
                        },
                    }
                }
            };
        }
    }
