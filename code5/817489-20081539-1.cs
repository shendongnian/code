            public static void ContentDelegateHandler(SomeContent content)
            {
                Console.WriteLine(content.ValueOne);
                Console.WriteLine(content.ValueTwo);
                content.ValueOne = "updated";
            }
