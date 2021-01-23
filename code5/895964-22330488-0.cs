    class ListCategorieArticlesConfigAdapter : BaseAdapter
    {
        private List<CategoriesArticlesConfig> list;
        private Activity Activity;
        public ListCategorieArticlesConfigAdapter(Android.App.Activity Activity, List<CategoriesArticlesConfig> list)
            : base()
        {
            this.Activity = Activity;
            this.list = list;
        }
        public override int Count
        {
            get { return list.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return list[position].CategorieArticlesConfigID;
        }
        public override Android.Views.View GetView(int position, Android.Views.View convertView,
            Android.Views.ViewGroup parent)
        {
            ViewHolder vh;
            var view = convertView;
            if (view == null)
            {
                view = Activity.LayoutInflater.Inflate(Resource.Layout.list_item_categories_articles_configuration,
                    false);
                vh = new ViewHolder(list);
                vh.Initialize(view);
                view.Tag = vh;
            }
            vh = view.Tag as ViewHolder;
            vh.Bind(position);
            return view;
        }
        private class ViewHolder : Java.Lang.Object
        {
            private TextView _nom;
            private Button _modify;
            private Button _delete;
            private List<CategoriesArticlesConfig> _list;
            public ViewHolder(List<CategoriesArticlesConfig> list)
            {
                _list = list;
            }
            public void Initialize(View view)
            {
                _nom = view.FindViewById<TextView>(Resource.Id.tv_nom_list_item_categories_articles_configuration);
                _modify = view.FindViewById<Button>(Resource.Id.bt_modify_list_categories_articles_configuration);
                _delete = view.FindViewById<Button>(Resource.Id.bt_delete_list_categories_articles_configuration);
            }
            public void Bind(int position)
            {
                _modify.Tag = position;
                _modify.Click += modify_Click;
                _delete.Click += delete_Click;
                _nom.Text = _list[position].Nom;
            }
            void delete_Click(object sender, EventArgs e)
            {
                var indice = (int)(((View)sender).Tag);
                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(Activity);
                builder.SetMessage(Resource.String.msg_supprimer);
                builder.SetPositiveButton(Resource.String.oui, delegate
                {
                    CSDatabase.ExecuteNonQuery("DELETE FROM CategoriesArticlesConfig WHERE CategorieArticlesConfigID=" + list[indice].CategorieArticlesConfigID);
                    list.RemoveAt(indice);
                    NotifyDataSetChanged();
                });
                builder.SetNegativeButton(Resource.String.non, (Android.Content.IDialogInterfaceOnClickListener)null);
                builder.Show();
            }
            void modify_Click(object sender, EventArgs e)
            {
                var indice = (int)(((View)sender).Tag);
                AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
                builder.SetTitle(Resource.String.modifier_categorie);
                LayoutInflater inflater = Activity.LayoutInflater;
                View v = inflater.Inflate(Resource.Layout.alertdialog_ajouter_categorie_article_configuration, null);
                TextView _nom = v.FindViewById<TextView>(Resource.Id.ed_nom_ajouter_categorie_fragment_article_configuration);
                _nom.Text = _list[indice].Nom;
                builder.SetNegativeButton(Resource.String.annuler, (Android.Content.IDialogInterfaceOnClickListener)null);
                builder.SetPositiveButton(Resource.String.modifier, delegate
                {
                    CategoriesArticlesConfig c = CategoriesArticlesConfig.ReadFirst("CategorieArticlesConfigID=" + list[indice].CategorieArticlesConfigID);
                    if (c != null)
                    {
                        c.Nom = _nom.Text;
                        c.Save();
                    }
                    _list[indice].Nom = _nom.Text;
                    NotifyDataSetChanged();
                });
                builder.SetView(v);
                builder.Show();
            }
        }
    }
