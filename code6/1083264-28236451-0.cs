    NumberPicker picker;
    protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.test);
                picker  = FindViewById<NumberPicker>(Resource.Id.numberPicker);
                picker.MaxValue = 40;
                picker.MinValue = 1;
                EditText editText= (EditText)picker.GetChildAt(1);
                editText.SetOnEditorActionListener(new CustomActionListener());
                
            }
    
     public class CustomActionListener : Java.Lang.Object,EditText.IOnEditorActionListener
            {
    
                public bool OnEditorAction(TextView v, Android.Views.InputMethods.ImeAction actionId, KeyEvent e)
                {
         
                    if(actionId == Android.Views.InputMethods.ImeAction.Done)
                    {
                        // Here is you number
                        string countNumber = v.Text;
                    }
                    return true;
          
                }
    
                public IntPtr Handle
                {
                    get { return base.Handle; }
                }
    
                public void Dispose()
                {
                    base.Dispose();
                }
            }
     
      
        
