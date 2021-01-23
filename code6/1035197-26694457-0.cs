    public static class NotifyIconExtesionMethods {
        public static MyClass As<T>( this NotifyIcon notifyIcon ) {
            return notifyIcon.Tag as T;
        }
    }
    
    class MyClass {
        private NotifyIcon notifyIcon;
        
        public MyClass( ) {
            notifyIcon = ...;
            ...
            notifyIcon.Tag = this;
        }
        public T As<T>( ) {
            return notifyIcon as T;
        }
    }
    
    //In some method:
    var notifyIcon = new MyClass( ).As<NotifyIcon>( );
    ...
    var myClass = notifyIcon.As<MyClass>( );
