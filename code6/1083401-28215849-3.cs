    namespace RemoteAPIProxy {
        public class Baz : IBaz {
            public string GetScore() {
                // initialization of network, API, etc
                Transport.Baz baz = new Transport.Baz.From(this);
                string score = CallRemoteAPI("BazGetScore", baz);
                return score;
            }
        }
    }
