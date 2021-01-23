    using Moq;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            var stateConverter = new Mock<StateConverter>();
            var solution = new Mock<Solution>();
            var state = new Mock<State>();
            var neightbourSolution1 = new Mock<Solution>();
            var neighbourState1 = new Mock<State>();
            var neightbourSolution2 = new Mock<Solution>();
            var neighbourState2 = new Mock<State>();
            stateConverter.Setup(x => x.FromSolution(neightbourSolution1.Object, It.IsAny<State>())).Returns(neighbourState1.Object);
            stateConverter.Setup(x => x.FromSolution(neightbourSolution2.Object, It.IsAny<State>())).Returns(neighbourState2.Object);
            var state1 = stateConverter.Object.FromSolution(neightbourSolution1.Object, state.Object);
            var state2 = stateConverter.Object.FromSolution(neightbourSolution2.Object, state.Object);
        }
    }
    public class State{}
    public class Solution{}
    public abstract class StateConverter
    {
        public abstract State FromSolution(Solution p0, State isAny);
    }
}
