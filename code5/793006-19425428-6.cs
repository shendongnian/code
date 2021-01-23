    public interface ICrazyThing<T>
    {
        void Get<T>(ref T crazy);
    }
    public class CrazyThing<U, T> : IThing<T> where T : U
    {
        private U u;
        public void Get<T>(ref T crazy)
        {
           crazy = this.u;   
        }
    }
