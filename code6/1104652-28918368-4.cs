        public interface IShuffable
        {
             void Shuffle();
        }
		class QuestionTypeA : Question, IShuffable
		{
            // question of type A can't change score
			public override bool ScoreReadonly { get {return true;}}
            public void Shuffle()
            {
              // Code to implement shuffling the choices
            }
		}
        class QuestionTypeB : Question {}
