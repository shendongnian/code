    public class MultiTypeDynamicTextBlock : TextBlock
    {
        public interface ISection
        {
            Inline GetDisplayElement();
            ISection Clone();
        }
        public class TextOption : ISection
        {
            private Run mText;
            public TextOption(string aText)
            {
                mText = new Run();
                mText.Text = aText.Replace("\\n", "\n");
            }
            public Inline GetDisplayElement()
            {
                return mText;
            }
            public ISection Clone()
            {
                return new TextOption(mText.Text);
            }
        }
        public class LineBreakOption : ISection
        {
            public Inline GetDisplayElement()
            {
                return new LineBreak();
            }
            public ISection Clone()
            {
                return new LineBreakOption();
            }
        }
        public class SectionList
        {
            private ObservableCollection<ISection> mList;
            public Action CollectionChanged;
            public ObservableCollection<ISection> Items
            {
                get
                {
                    ObservableCollection<ISection> lRet = new ObservableCollection<ISection>();
                    foreach (ISection lCurr in mList)
                    {
                        lRet.Add(lCurr.Clone());
                    }
                    return lRet;
                }
            }
            public int Count { get { return mList.Count; } }
            public SectionList()
            {
                mList = new ObservableCollection<ISection>();
            }
            public void Add(ISection aValue)
            {
                mList.Add(aValue);
            }
            public SectionList Clone()
            {
                SectionList lRet = new SectionList();
                lRet.mList = Items;
                return lRet;
            }
        }
        public MultiTypeDynamicTextBlock()
        {
            
        }
        public static readonly DependencyProperty ItemsCollectionProperty =
            DependencyProperty.Register("ItemsCollection", typeof(SectionList), typeof(MultiTypeDynamicTextBlock),
                new UIPropertyMetadata((PropertyChangedCallback)((sender, args) =>
                {
                    MultiTypeDynamicTextBlock textBlock = sender as MultiTypeDynamicTextBlock;
                    SectionList inlines = args.NewValue as SectionList;
                    if (textBlock != null)
                    {
                        if ((inlines != null) && (inlines.Count > 0))
                        {
                            textBlock.ItemsCollection.CollectionChanged += textBlock.ResetInlines;
                            textBlock.Inlines.Clear();
                            foreach (ISection lCurr in textBlock.ItemsCollection.Items)
                            {
                                textBlock.Inlines.Add(lCurr.GetDisplayElement());
                            }
                        }
                        else
                        {
                            inlines = new SectionList();
                            inlines.Add(new TextOption("No value set"));
                            textBlock.ItemsCollection = inlines;
                        }
                    }
                })));
        public SectionList ItemsCollection
        {
            get
            {
                return (SectionList)GetValue(ItemsCollectionProperty);
            }
            set
            {
                SectionList lTemp;
                if (value == null)
                {
                    lTemp = new SectionList();
                    lTemp.Add(new TextOption("No value set for property"));
                }
                else
                {
                    lTemp = value;
                }
                SetValue(ItemsCollectionProperty, lTemp);
            }
        }
        private void ResetInlines()
        {
            Inlines.Clear();
            foreach (ISection lCurr in ItemsCollection.Items)
            {
                Inlines.Add(lCurr.GetDisplayElement());
            }
        }
    }
