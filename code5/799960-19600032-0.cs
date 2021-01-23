    using System;
    using System.Activities;
    using Microsoft.Win32;
    using System.IO;
    public class GetRegistryValue : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> KeyPath { get; set; }
        public OutArgument<string> TextOut { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string keyPath = this.KeyPath.Get(context);
            string keyName = Path.GetDirectoryName(keyPath);
            string valueName = Path.GetFileName(keyPath);
            object value = Registry.GetValue(keyName, valueName, "");
            context.SetValue(this.TextOut, value.ToString());
        }
    }
