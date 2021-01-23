    using (AnonymousPipeServerStream pipeServer =
            new AnonymousPipeServerStream(PipeDirection.Out,
            HandleInheritability.Inheritable))
        {
           // .......
           int id = 123456;
           string msg = "hello";
           using(var binWriter = new BinaryWriter(pipeServer))
           {
              binWriter.Write(id);
              binWriter.Write(msg);
           }
        }
    }
