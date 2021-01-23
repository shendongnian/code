       public static Hyperlink GetHyberLink(this TextPointer pointer)
         {
             if (pointer == null)
             {
                 return null;
             }     
             Inline parent = pointer.Parent as Inline;
             while (parent != null && !(parent is Hyperlink))
             {
                 parent = parent.Parent as Inline;
             }
             return parent == null ? null : (Hyperlink)parent;
         }
