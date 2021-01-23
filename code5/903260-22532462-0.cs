        static TiltEffect()
        {
            // The tiltable items list.
            TiltableItems = new List<Type>() { typeof(ButtonBase), typeof(ListBoxItem), };
            TiltableItems.Add(typeof(Border));
            TiltableItems.Add(typeof(TiltEffectAbleControl));
            UseLogarithmicEase = false;
        }
