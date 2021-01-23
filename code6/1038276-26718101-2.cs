    public class BubbleAdapter : ArrayAdapter<BubbleEntity>
        {
    
            /// <summary>
            /// The context of the activity
            /// </summary>
            private Activity _context;
    
            /// <summary>
            /// The list that holds the bubble strings
            /// </summary>
            private List<BubbleEntity> _bubbleList;
    
            /// <summary>
            /// Creates a new Instance of the <see cref="FloatStringAdapter"/> - Class
            /// </summary>
            /// <param name="context"></param>
            /// <param name="floatStringList"></param>
            public BubbleAdapter(Activity context, List<BubbleEntity> bubbleList)
                : base(context, Resource.Layout.list_bubble, bubbleList)
            {
                  this._context = context;
                  this._bubbleList = bubbleList;
            }
    
         public override View GetView(int position, View convertView, ViewGroup parent)
                {
                   
                    // Get our object for this position
                    var item = this._bubbleList[position];
                    var view = (convertView ??
                           this._context.LayoutInflater.Inflate(
                           Resource.Layout.list_bubble,
                           parent,
                           false)) as LinearLayout;
        
                    TextView username = view.FindViewById<TextView>(Resource.Id.list_bubble_userName);
                    TextView message = view.FindViewById<TextView>(Resource.Id.list_bubble_message);
                    username.TextFormatted = Html.FromHtml(item.UserNameText);
                    message.Text = item.Text;
                    if(item.IsTheDeviceUser == false)
                    {
                        view.SetGravity(GravityFlags.Left);
                        message.SetBackgroundResource(Resource.Drawable.bubble_other);     
                    }
                    else
                    {
                        view.SetGravity(GravityFlags.Right);
                        message.SetBackgroundResource(Resource.Drawable.bubble_user);
                    }
        
                     return view;
                }
    }
