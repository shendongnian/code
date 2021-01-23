    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace NeuralNetwork
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Training Network...");
    
                Random r = new Random();
                var network = new NeuralNetwork(1, 3, 1);
                for (int k = 0; k < 60; k++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        double x = i / 1000.0;// r.Next();
                        double y = 3 * x;
                        network.Train(x);
                        network.BackPropagate(y);
                    }
                    double output = network.Compute(0.2)[0];
                    Console.WriteLine(output);
                }
                //Below should output 10, but instead outputs either a very large number or NaN
               /* double output = network.Compute(3)[0];
                Console.WriteLine(output);*/
            }
        }
    
        public class NeuralNetwork
        {
            public double LearnRate { get; set; }
            public double Momentum { get; set; }
            public List<Neuron> InputLayer { get; set; }
            public List<Neuron> HiddenLayer { get; set; }
            public List<Neuron> OutputLayer { get; set; }
            static Random random = new Random();
    
            public NeuralNetwork(int inputSize, int hiddenSize, int outputSize)
            {
                LearnRate = .2;
                Momentum = .04;
                InputLayer = new List<Neuron>();
                HiddenLayer = new List<Neuron>();
                OutputLayer = new List<Neuron>();
    
                for (int i = 0; i < inputSize; i++)
                    InputLayer.Add(new Neuron());
    
                for (int i = 0; i < hiddenSize; i++)
                    HiddenLayer.Add(new Neuron(InputLayer));
    
                for (int i = 0; i < outputSize; i++)
                    OutputLayer.Add(new Neuron(HiddenLayer));
            }
    
            public void Train(params double[] inputs)
            {
                int i = 0;
                InputLayer.ForEach(a => a.Value = inputs[i++]);
                HiddenLayer.ForEach(a => a.CalculateValue());
                OutputLayer.ForEach(a => a.CalculateValue());
            }
    
            public double[] Compute(params double[] inputs)
            {
                Train(inputs);
                return OutputLayer.Select(a => a.Value).ToArray();
            }
    
            public double CalculateError(params double[] targets)
            {
                int i = 0;
                return OutputLayer.Sum(a => Math.Abs(a.CalculateError(targets[i++])));
            }
    
            public void BackPropagate(params double[] targets)
            {
                int i = 0;
                OutputLayer.ForEach(a => a.CalculateGradient(targets[i++]));
                HiddenLayer.ForEach(a => a.CalculateGradient());
                HiddenLayer.ForEach(a => a.UpdateWeights(LearnRate, Momentum));
                OutputLayer.ForEach(a => a.UpdateWeights(LearnRate, Momentum));
            }
    
            public static double NextRandom()
            {
                return 2 * random.NextDouble() - 1;
            }
    
            public static double SigmoidFunction(double x)
            {
               if (x < -45.0)
                {
                    return 0.0;
                }
                else if (x > 45.0)
                {
                    return 1.0;
                }
                return 1.0 / (1.0 + Math.Exp(-x));
               
            }
    
            public static double SigmoidDerivative(double f)
            {
                return f * (1 - f);
            }
    
            public static double HyperTanFunction(double x)
            {
                if (x < -10.0) return -1.0;
                else if (x > 10.0) return 1.0;
                else return Math.Tanh(x);
            }
    
            public static double HyperTanDerivative(double f)
            {
                return (1 - f) * (1 + f);
            }
    
            public static double IdentityFunction(double x)
            {
                return x;
            }
    
            public static double IdentityDerivative()
            {
                return 1;
            }
        }
    
        public class Neuron
        {
            public bool IsInput { get { return InputSynapses.Count == 0; } }
            public bool IsHidden { get { return InputSynapses.Count != 0 && OutputSynapses.Count != 0; } }
            public bool IsOutput { get { return OutputSynapses.Count == 0; } }
            public List<Synapse> InputSynapses { get; set; }
            public List<Synapse> OutputSynapses { get; set; }
            public double Bias { get; set; }
            public double BiasDelta { get; set; }
            public double Gradient { get; set; }
            public double Value { get; set; }
    
            public Neuron()
            {
                InputSynapses = new List<Synapse>();
                OutputSynapses = new List<Synapse>();
                Bias = NeuralNetwork.NextRandom();
            }
    
            public Neuron(List<Neuron> inputNeurons)
                : this()
            {
                foreach (var inputNeuron in inputNeurons)
                {
                    var synapse = new Synapse(inputNeuron, this);
                    inputNeuron.OutputSynapses.Add(synapse);
                    InputSynapses.Add(synapse);
                }
            }
    
            public virtual double CalculateValue()
            {
                var d = InputSynapses.Sum(a => a.Weight * a.InputNeuron.Value);// + Bias;
                return Value = IsHidden ? NeuralNetwork.SigmoidFunction(d) : NeuralNetwork.IdentityFunction(d);
            }
    
            public virtual double CalculateDerivative()
            {
                var d = Value;
                return IsHidden ? NeuralNetwork.SigmoidDerivative(d) : NeuralNetwork.IdentityDerivative();
            }
    
            public double CalculateError(double target)
            {
                return target - Value;
            }
    
            public double CalculateGradient(double target)
            {
                return Gradient = CalculateError(target) * CalculateDerivative();
            }
    
            public double CalculateGradient()
            {
                return Gradient = OutputSynapses.Sum(a => a.OutputNeuron.Gradient * a.Weight) * CalculateDerivative();
            }
    
            public void UpdateWeights(double learnRate, double momentum)
            {
                var prevDelta = BiasDelta;
                BiasDelta = learnRate * Gradient; // * 1
                Bias += BiasDelta + momentum * prevDelta;
    
                foreach (var s in InputSynapses)
                {
                    prevDelta = s.WeightDelta;
                    s.WeightDelta = learnRate * Gradient * s.InputNeuron.Value;
                    s.Weight += s.WeightDelta; //;+ momentum * prevDelta;
                }
            }
        }
    
        public class Synapse
        {
            public Neuron InputNeuron { get; set; }
            public Neuron OutputNeuron { get; set; }
            public double Weight { get; set; }
            public double WeightDelta { get; set; }
    
            public Synapse(Neuron inputNeuron, Neuron outputNeuron)
            {
                InputNeuron = inputNeuron;
                OutputNeuron = outputNeuron;
                Weight = NeuralNetwork.NextRandom();
            }
        }
    }
