    public class UniqueHolder : IDisposable
    {
        public Guid UniqueID { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is UniqueHolder)
            {
                
                return Guid.Equals(((UniqueHolder)obj).UniqueID, this.UniqueID);
            }
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return UniqueID.GetHashCode();
        }
        private TextBox textbox;
        public TextBox TextBox
        {
            get
            {
                return textbox;
            }
            set
            {
                if (object.Equals(textbox, value))
                {
                    return;
                }
                if (textbox != null)
                {
                    textbox.TextChanged -= OnTextChanged;
                }
                textbox = value;
                if (textbox != null)
                {
                    textbox.TextChanged += OnTextChanged;
                }
            }
        }
        private Ingredient ingredient;
        public Ingredient Ingredient 
        {
            get
            {
                return ingredient;
            }
            set
            {
                if (object.Equals(ingredient, value))
                {
                    return;
                }
                if (ingredient != null)
                {
                    ingredient.PropertyChanged -= OnIngredientChanged;
                }
                ingredient = value;
                if (ingredient != null)
                {
                    ingredient.PropertyChanged += OnIngredientChanged;
                }
            }
        }
        public UniqueHolder()
        {
            this.UniqueID = Guid.NewGuid();
        }
        protected virtual void OnIngredientChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, "Title", StringComparison.OrdinalIgnoreCase))
            {
                if (TextBox == null)
                {
                    return;
                }
                TextBox.Text = Ingredient.Title;
            }
        }
        protected virtual void OnTextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null)
            {
                return;
            }
            if (Ingredient == null)
            {
                return;
            }
            Ingredient.Title = tb.Text;
        }
        public void Dispose()
        {
            Ingredient = null;
            TextBox = null;
        }
    }
