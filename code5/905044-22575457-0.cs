    public abstract class SpaceshipManager : MonoBehaviour
    {
        public abstract void BuildWith(ParseObject po);
        public void BuildWith(string label)
        {
            // Static method or constructor here to represent label as a ParseObject.
            BuildWith(ParseObject.FromLabel(label))
        }
    }
