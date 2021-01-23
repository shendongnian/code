    catch (MQException mqex)
    {
       System.Console.Out.WriteLine("MQException cc=" + mqex.CompletionCode + " : rc=" + mqex.ReasonCode);
    }
    catch (System.IO.IOException ioex)
    {
       System.Console.Out.WriteLine("IOException ioex=" + ioex);
    }
    catch (Exception ex)
    {
       System.Console.Out.WriteLine("Exception ex=" + ex);
    }
