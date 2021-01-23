        public class YourClass: YourBaseClass
        {
            QuizArgs args = null;
            protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
            {
                args = navigationParameter as QuizArgs;
                var SectorGroups = QuizDataSource.GetGroups(args.sector);
                this.DefaultViewModel["Groups"] = SectorGroups;
            }
            void ItemView_ItemClick(object sender, ItemClickEventArgs e)
            {
                 if(args == null)
                     throw new NullReferenceException();
                 var itemId = args.UniqueId;
                 var sectorId = new QuizArgs
                 {
                     sector = "nav",
                     question = 2,
                     Total = 0,
                     type=itemId
                 };
                 this.Frame.Navigate(typeof(Quiz), sectorId);
            }
        }
