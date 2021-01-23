    public static class Foo {
       public static String SomeMethod (this Bar bar) {
           return bar.OriginalMethod()+" test";
       }
    }
