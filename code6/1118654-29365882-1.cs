            public class DeeplyAffectedCanvas : Canvas
            {
                private IDictionary<CanvasElement, Action> m_dictionary;
                public void SpecialTransform(CanvasElement elem, Action transform) { }
                public override void Resize() 
                { 
                    // Resize, for example, have to take into account
                    // the special operation
                }
            }
