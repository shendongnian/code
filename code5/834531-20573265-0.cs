    using (AnonymousPipeServerStream pipeServer =
            new AnonymousPipeServerStream(PipeDirection.Out,
            HandleInheritability.Inheritable))
        {
           // .......
           using(var binWriter = new BinaryWriter(pipeServer))
           {
              binWriter.Write(123456);
           }
        }
    }
