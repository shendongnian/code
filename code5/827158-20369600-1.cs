        public interface IImageFilterBase {
          object Input { get; set; }
          string Name { get; set; }
          Guid Guid { get; set; }
          object Process(object frame);
        }
        public interface IImageFilter<TIn, TOut> : IImageFilterBase {
          // Properties
          new TIn Input { get; set; }
          TOut Process(TIn frame);
        }
        public abstract class FilterBase<TIn, TOut> : IImageFilter<TIn, TOut> {
          public TIn Input { get; set; }
          public abstract TOut Process(TIn frame);
          object IImageFilterBase.Input {
            get { return this.Input; }
            set { this.Input = (TIn)value; }
          }
          public string Name { get;set;}
          public Guid Guid { get; set; }
          public object Process(object frame) {
            return this.Process((TIn)frame);
          }
        }
        // test class
        public class StringToInt32 : FilterBase<string, int> {
          public override int Process(string frame) {
            return Convert.ToInt32(frame);
          }
        }
