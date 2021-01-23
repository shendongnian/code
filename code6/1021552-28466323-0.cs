    using System;
    using System.Threading;
    using System.Speech;
    using System.Speech.Synthesis;
    using System.Speech.Recognition;
    
    namespace SpeachTest
    {
    public class GrammerTest
    {
            static void Main()
            {
            Choices choiceList = new Choices();
            choiceList.Add(new string[]{"what", "is", "a", "car", "are", "you", "robot"} );
            
            GrammarBuilder builder = new GrammarBuilder();
            builder.Append(choiceList);
            Grammar grammar = new Grammar(new GrammarBuilder(builder, 0, 4) );   //Will recognize a minimum of 0 choices, and a maximum of 4 choices
            
                SpeechRecognizer speechReco = new SpeechRecognizer();
                speechReco.LoadGrammar(grammar);
    
    
    
            }
    }
    }
