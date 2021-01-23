    public class MyMessageEncoder : MessageEncoder {
       public MyMessageEncoder(MessageEncoder innerMessageEncoder) {
			this.InnerMessageEncoder = innerMessageEncoder;			
		}
       public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType) {
			Message message = this.InnerMessageEncoder.ReadMessage(buffer, bufferManager, contentType);
			//access message properties by message.Properties here
			return message;
		}
                //other methods
    }
