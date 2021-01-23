    public class myVectorMyType : global::System.IDisposable {
      private global::System.Runtime.InteropServices.HandleRef swigCPtr;
      protected bool swigCMemOwn;
    
      ...
    
      public virtual vector_MyType getVect() {
        vector_MyType ret = new vector_MyType(PandoraWrapperPINVOKE.myVectorMyType_getVect(swigCPtr), false);
        return ret;
      }
    }
